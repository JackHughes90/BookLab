import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {
  getBooksBySearch,
  getAuthorsBySearch,
  Book,
  Author,
} from "../../clients/apiClient";
import { useParams } from "react-router-dom";
import { BookCard } from "../card/BookCard";
import { AuthorCard } from "../card/AuthorCard";
import { Books } from "../books/Books";
import { Authors } from "../authors/Authors";

export const Search: React.FC = () => {
  const [books, setBooks] = useState<Book[]>();
  const [authors, setAuthors] = useState<Author[]>();
  const { searchTerm } = useParams<{ searchTerm: string }>();

  useEffect(() => {
    getBooksBySearch(searchTerm).then(setBooks);
    getAuthorsBySearch(searchTerm).then(setAuthors);
  }, [searchTerm]);

  if (books === undefined || authors === undefined) {
    return <Books />;
  }

  return (
    <>
      <h1>Search Results for &quot;{searchTerm}&quot;</h1>
      <h2>Books:</h2>
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
      <h2>Authors:</h2>
      <div className="author-list">
        {authors.map((author) => {
          const authorRoute = "/authors/" + author.id;
          return (
            <Link
              className="author-list__link"
              key={author.id}
              to={authorRoute}
            >
              <AuthorCard author={author} />
            </Link>
          );
        })}
      </div>
    </>
  );
};
