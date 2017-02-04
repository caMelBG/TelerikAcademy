FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    Evacuation.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
