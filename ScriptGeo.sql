CREATE TABLE Square (
    SquareId integer not null auto_increment,
    StartX float,
    StartY float,
    Size Integer,
    primary key(SquareId)
);

CREATE TABLE Line (
    LineId integer not null auto_increment,
    StartX float,
    StartY float,
    EndX float,
    EndY float,
    primary key(LineId)
);