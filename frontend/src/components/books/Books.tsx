import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAllBooks, Book } from "../../clients/apiClient";
import { BookCard } from "../card/BookCard";
import "./Books.scss";
// import { library } from '@fortawesome/fontawesome-svg-core';
// import { fas } from '@fortawesome/free-solid-svg-icons';
// import {
//   IconLookup,
//   IconDefinition,
//   findIconDefinition
// } from '@fortawesome/fontawesome-svg-core';
// import '@fortawesome/fontawesome-svg-core/styles.css'

export const Books: React.FunctionComponent = () => {
  const [books, setBooks] = useState<Book[]>();
  const [search, setSearch] = useState("");

  useEffect(() => {
    getAllBooks().then(setBooks);
  }, []);

  if (books === undefined) {
    return <p>Loading...</p>;
  }

  function handleSearch(newSearchQuery: any) {
    setSearch(newSearchQuery);
  }

  return (
    <>
      <h1>Books</h1>
      <div className="book-form">
        <i className="fa-solid fa-magnifying-glass"></i>
        <label>
          <input
            type="text"
            placeholder="Search..."
            onChange={(e) => handleSearch(e.target.value)}
          />
        </label>
      </div>
      <div className="book-list">
        {books.map((book) => {
          const bookRoute = "/books/" + book.id;
          if (
            book.title.toLowerCase().includes(search.toLowerCase()) ||
            book.authors[0].name.toLowerCase().includes(search.toLowerCase())
          ) {
            return (
              <Link className="book-list__link" key={book.id} to={bookRoute}>
                <BookCard book={book} />
              </Link>
            );
          }
        })}
      </div>
    </>
  );
};
