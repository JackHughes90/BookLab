import React, { useEffect, useState } from "react";
import { getBookById, Book } from "../../clients/apiClient";
import { useParams } from "react-router-dom";
import { Books } from "../books/Books";

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
    <div className="book-profile">
      <h1>{book.title}</h1>
    </div>
  );
};
