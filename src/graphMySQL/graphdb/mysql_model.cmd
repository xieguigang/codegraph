REM @echo off

SET Reflector="../../mysqli/App/Reflector.exe"
SET sql_src="../../web/mysql/graphdb.sql"

%Reflector% --reflects /sql %sql_src% -o ./ /namespace graphdb --language visualbasic /split

pause