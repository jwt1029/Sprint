참고 : http://code.p-ark.co.kr/374

[통신 JSON 스펙]
{
	"header" 	: "login"
	"id"	 	: value
	"pw"	 	: value
}

{
	"header"	: "register"
	"id"		: value
	"pw"		: value
}

{
	"header"	: "join"
	"usercode"	: value
	"roomnum"	: value
	"roompw"	: value
}

{
	"header" 	: "left"
}

{
	"header"	: "usercode"
	"usercode"	: value
}

모든 json 통신은 그 통신 데이터에 해당하는 "header"가 존재하고
header에 따라 서버와 클라이언트는 각각 명령어에 맞게 데이터를 처리한다.