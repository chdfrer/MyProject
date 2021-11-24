Steps to add service to DI:

	1. Preparation: pakage MailKit, MimeKit

		dotnet add package MailKit
		dotnet add package MimeKit
	
	
	2. Write mailsetting information in appsetting.json.
		
		"MailSettings": {
		"Mail": "Địa chỉ gmail sử dụng để gởi mail",
		"DisplayName": "Tên Hiện Thị",
		"Password": "passowrd",
		"Host": "smtp.gmail.com",
		"Port": 587
	  }

	3. Call services.AddSendMailService(Configuration) in ConfigureService method in Startup.cs.
	
	SendMailService is ready to use!