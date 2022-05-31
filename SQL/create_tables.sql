CREATE TABLE tab_answers
(
    id      INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    answer  TEXT    NOT NULL,
    correct INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE tab_questions
(
    id       INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    question TEXT    NOT NULL
);

CREATE TABLE tab_questions_answers
(
    id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    question_id INTEGER NOT NULL,
    answer_id   INTEGER NOT NULL,
    FOREIGN KEY (question_id) REFERENCES tab_questions (id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    FOREIGN KEY (answer_id) REFERENCES tab_answers (id) 
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);