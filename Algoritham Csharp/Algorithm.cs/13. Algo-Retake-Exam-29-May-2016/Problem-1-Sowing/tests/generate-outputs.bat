FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    Sowing.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
