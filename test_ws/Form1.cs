using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using test_ws.ServiceReference1;

namespace test_ws
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox9.Text)) {
                    throw new Exception("Err: User and/or password cannot be null");
                }

                richTextBox1.Text = "";
                TransactionClient client = new TransactionClient();
                using (new OperationContextScope(client.InnerChannel))
                {
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["username"] = textBox1.Text;
                    requestMessage.Headers["password"] = textBox9.Text;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    string arg0 = textBox2.Text,
                        arg1 = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        arg2 = textBox4.Text,
                        arg3 = textBox5.Text,
                        arg4 = textBox6.Text,
                        arg5 = textBox7.Text,
                        arg6 = textBox8.Text;

                    string s = client.setToken(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
                    richTextBox1.Text = s;
                }
            }
            catch(Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }
            
        }
    }
}
