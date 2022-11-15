import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAllBooks, Book } from "../../clients/apiClient";
import { BookCard } from "../card/BookCard";
import "./Books.scss";

export const Books: React.FunctionComponent = () => {
  const [books, setBooks] = useState<Book[]>();

  useEffect(() => {
    getAllBooks().then(setBooks);
  }, []);

  if (books === undefined) {
    return <p>Loading...</p>;
  }

  return (
    <>
      <h1>Books</h1>
      <div className="book-list">
        {books.map((book) => {
          const bookRoute = "/books/" + book.id;
          return (
            <Link className="book-list__link" key={book.id} to={bookRoute}>
              <BookCard book={book} />
            </Link>
          );
        })}
      </div>
    </>
  );
};
