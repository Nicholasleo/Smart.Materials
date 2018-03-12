using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main
{
    /// <summary>
    /// 提示消息窗体
    /// </summary>
    public class DialogMessagebox
    {
        public static DialogResult Show(string msg, string title, MessageBoxButtons buttons)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, title, buttons);
        }
        public static DialogResult Show(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, title, buttons, icon);
        }
        public static DialogResult Show(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, title, buttons, icon, defaultButton);
        }
        #region 信息提示ShowInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ShowInfo(string msg)
        {
            return ShowInfo(msg, "系统提示");
        }
        public static DialogResult ShowInfo(string msg, string title)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 信息提示ShowInfoError
        public static DialogResult ShowInfoError(string msg)
        {
            return ShowInfoError(msg, "系统提示");
        }
        public static DialogResult ShowInfoError(string msg, string title)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region 信息提示ShowInfoQuestion
        public static DialogResult ShowInfoQuestion(string msg)
        {
            return ShowInfoQuestion(msg, "系统提示");
        }
        public static DialogResult ShowInfoQuestion(string msg, string title)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        #region 信息提示ShowInfoWarning
        public static DialogResult ShowInfoWarning(string msg)
        {
            return ShowInfoWarning(msg, "系统提示");
        }
        public static DialogResult ShowInfoWarning(string msg, string title)
        {
            Cursor.Current = Cursors.Default;
            return XtraMessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

    }





    public class ThreadMsg
    {
        public static void ShowMsg(string msg, string title)
        {
            XtraMessageBox.Show(msg, title);
        }

        public static void ShowText(string showText, string title, string saveFileName)
        {
            //new FrmShowText(title, showText, saveFileName).ShowDialog();
        }

        public static void ThreadShowMsg(Form frm, string msg, string title, bool IfInvoke)
        {
            if (IfInvoke)
            {
                frm.Invoke(new ShowMsgDel(ThreadMsg.ShowMsg), new object[] { msg, title });
            }
            else
            {
                frm.BeginInvoke(new ShowMsgDel(ThreadMsg.ShowMsg), new object[] { msg, title });
            }
        }

        public static void ThreadShowText(Form frm, string showText, string title, string saveFileName, bool IfInvoke)
        {
            if (IfInvoke)
            {
                frm.Invoke(new ShowTextDel(ThreadMsg.ShowText), new object[] { showText, title, saveFileName });
            }
            else
            {
                frm.BeginInvoke(new ShowTextDel(ThreadMsg.ShowText), new object[] { showText, title, saveFileName });
            }
        }

        private delegate void ShowMsgDel(string msg, string title);

        private delegate void ShowTextDel(string msg, string title, string saveFileName);
    }
}