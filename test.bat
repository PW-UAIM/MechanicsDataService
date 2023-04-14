echo off
set url=https://localhost:5002

CALL:curl_test "Dane mechanika o ID 1" GET /mechanic/1 

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept:application/json'
echo:
echo:
pause