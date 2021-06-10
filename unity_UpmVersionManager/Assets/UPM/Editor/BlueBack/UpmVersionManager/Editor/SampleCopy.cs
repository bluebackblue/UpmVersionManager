

/** BlueBack.UpmVersionManager.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.UpmVersionManager.Editor
{
    /** SampleCopy
    */
    public class SampleCopy
    {
        /** s_process
        */
        private static System.Diagnostics.Process s_process = null;

        /** Copy
        */
        public static void Copy()
        {
            s_process = new System.Diagnostics.Process();
            {
                s_process.StartInfo.FileName = UnityEngine.Application.dataPath + "/Editor/VersionManager/SampleCopy.bat";
                s_process.StartInfo.Arguments = Setting.PACKAGE_NAME;
                s_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                s_process.StartInfo.UseShellExecute = true;
                s_process.Exited += ExitProcess;
                s_process.Start();
            }
        }

        /** ExitProcess
        */
        private static void ExitProcess(object a_sender,System.EventArgs a_eventargs)
        {
            if(s_process != null){
                s_process.Dispose();
                s_process = null;
            }
        }
    }
}
#endif

