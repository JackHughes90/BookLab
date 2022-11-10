import React from "react";
import { Book } from "../../clients/apiClient";
import { Card } from "../card/Card";
import "./BookCard.scss";

interface BookCardProps {
  book: Book;
}

export const BookCard: React.FC<BookCardProps> = ({ book }) => {
  return (
    <Card imageUrl={book.coverUrl} title={book.title}>
      <div className="book-card__authors">
        {book.authors.map((author) => {
          return (
            <span className="book-card__authors--author" key={author.id}>
              {author.name}
            </span>
          );
        })}
      </div>
      {/* <div className="book-card__description">
        {book.description}
      </div> */}
      <div className="book-card__genres">
        {book.genres.map((genre) => {
          return (
            <span className="book-card__genres--genre" key={genre.id}>
              #{genre.name}
            </span>
          );
        })}
      </div>
    </Card>
  );
};
