Snippet for deleting bin and obj

start for /d /r . %%d in (bin,obj, ClientBin,Generated_Code) do @if exist "%%d" rd /s /q "%%d"


for /d /r . %d in (bin,obj) do @if exist "%d" rd /s/q "%d"