CREATE TABLE arima_kinen
(
    umaban INTEGER PRIMARY KEY,
	wakuban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo INTEGER NOT NULL,
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL
);

CREATE TABLE takarazuka_kinen
(
    umaban INTEGER PRIMARY KEY,
	wakuban INTEGER NOT NULL,
	bamei TEXT NOT NULL,
	seibetu TEXT NOT NULL,
	barei INTEGER NOT NULL,
	kinryo INTEGER NOT NULL,
	kisyu TEXT NOT NULL,
	kyusya TEXT NOT NULL,
	createdate TEXT NOT NULL,
	updatedate TEXT NOT NULL
);