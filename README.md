# Roblox-Key-System
based on .php file ( no database needed ) also this is only 1-time key system ( HWID Added if you have private keys ), if the key is used, it wouldn't longer valid until you get new key. Unless you can utilize this Key System to 24 Hours Key System on ( .NET / C# ). Yes could possible on C++ but i don't have that code lol


For C#
```
                string key = InputBox.Text; 
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                if (new WebClient().DownloadString("https://yourshitwebsite.xyz/check.php?key=" + key) != "Whitelisted") //change the site with your own site lmfao
                {
                    System.Windows.MessageBox.Show("Invalid Key or Already Used Key");
                    return;
                }
```

What you need:

1.] Your Braincells ( need it badly )

2.] A Custom Domain ofc so google recaptcha will work

3.] Google Recaptcha ( v2 )


Edit the index.php then replace the site key & secret key with yours

https://www.google.com/recaptcha/admin/create

Good Luck :)

Credit To:

[ + ] SkieHacker ( Modding & Improving the Key System )

[ + ] UsifFar ( for index.php, i watch his tutorial and i learn some shits at least )
