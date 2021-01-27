using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.AutoStartRadio
{
    public class AutoStartRadioPlugin: ISharpPlugin
    {
        private const int DEFAULT_INTERVAL = 5000;
        private const string _displayName = "Auto Start Radio";
        private long _frequency = 0;
        private ISharpControl _control;
                        
        private AutoStartPanel _guiControl;
        
        public string DisplayName
        {
            get { return _displayName; }
        }

        public UserControl Gui
        {
            get { return _guiControl; }
        }

        public void Initialize(ISharpControl control)
        {
            _guiControl = new AutoStartPanel();
            _control = control;
            _frequency = Utils.GetLongSetting("asrfrequency", 0);
            Timer timer = new Timer();
            timer.Interval = DEFAULT_INTERVAL;
            timer.Tick += (sender, e) =>
            {
                timer.Enabled = false;
                StartRadio();
            };
            timer.Enabled = true;
        }

        public void Close()
        {
        }        
        /// <summary>
        /// Attempts to start the radio
        /// </summary>
        private void StartRadio()
        {
            try
            {
                if (_control != null)
                {
                    _control.StartRadio();
                    // once we have started, check if we need to set frequency
                    if (_frequency == 0)
                        return;
                    // set the tuning timer
                    Timer timer = new Timer();
                    timer.Interval = DEFAULT_INTERVAL;
                    timer.Tick += (sender, e) =>
                    {
                        timer.Enabled = false;
                        TuneRadio();
                    };
                    timer.Enabled = true;
                }
            }
            catch (System.ApplicationException)
            {
                MessageBox.Show("Could not start the radio, is there a device connected?", "Auto Start Radio");
            }
        }
        /// <summary>
        /// Attempts to tune the radio to a set frequency
        /// </summary>
        private void TuneRadio()
        {
            try
            {
                if (_control != null)
                {
                    
                    _control.SetFrequency(_frequency, false);
                }
            }
            catch (System.ApplicationException)
            {
                MessageBox.Show("Could not tune the radio", "Auto Start Radio");
            }
        }
    }
}
