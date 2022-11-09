import React from "react";
import { Book } from "../../clients/apiClient";
import { Card } from "../card/Card";

interface BookCardProps {
  book: Book;
}

export const BookCard: React.FC<BookCardProps> = ({ book }) => {
  return (
    <Card
      imageUrl={book.coverUrl}
      title={book.title}
      description={book.description}
    />
  );
};
