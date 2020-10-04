using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var winFrom = new Window("WINDOW窗口");
            winFrom.AddChild(new Picture("LOGO图片"));
            winFrom.AddChild(new Button("登录"));
            winFrom.AddChild(new Button("注册"));
            winFrom.AddChild(CreateFrame());

            winFrom.Print();
        }

        private static IWindowElement CreateFrame()
        {
            var frame = new Frame("FRAME1");
            frame.AddChild(new Lable("用户名"));
            frame.AddChild(new TextBox("文本框"));
            frame.AddChild(new Lable("密码"));
            frame.AddChild(new PasswordBox("密码框"));
            frame.AddChild(new Checkbox("复选框"));
            frame.AddChild(new TextBox("记住用户名"));
            frame.AddChild(new LinkLable("忘记密码"));

            return frame;
        }
    }
}
