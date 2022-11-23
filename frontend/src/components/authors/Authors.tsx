import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAllAuthors, Author } from "../../clients/apiClient";
import { AuthorCard } from "../card/AuthorCard";
import "./Authors.scss";

export const Authors: React.FC = () => {
  const [authors, setAuthors] = useState<Author[]>();

  useEffect(() => {
    getAllAuthors().then(setAuthors);
  }, []);

  if (authors === undefined) {
    return <p>Loading...</p>;
  }

  return (
    <>
      <h1>Authors</h1>
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
