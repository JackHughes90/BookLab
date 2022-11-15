import React, { useEffect, useState } from "react";
import { getBookById, Book } from "../../clients/apiClient";
import { useParams } from "react-router-dom";
import { Books } from "../books/Books";
import "./BookSingle.scss";

export const BookSingle: React.FC = () => {
  const [book, setBook] = useState<Book>();
  const { bookId } = useParams<{ bookId: string }>();

  useEffect(() => {
    getBookById(bookId).then(setBook);
  }, [bookId]);

  if (book === undefined) {
    return <Books />;
  }

  return (
    <>
      <div className="book-profile">
        <img
          className="book-profile__image"
          src={book.coverUrl}
          alt={book.title}
        />
        <div className="book-profile__info">
          <h1>{book.title}</h1>
          <>
            {book.authors.map((author) => {
              return <h2 key={author.id}>{author.name}</h2>;
            })}
          </>
          <pre>{book.description}</pre>
        </div>
      </div>
    </>
  );
};
