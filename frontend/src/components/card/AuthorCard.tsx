import React from "react";
import { Author } from "../../clients/apiClient";
import { Card } from "../card/Card";

interface AuthorCardProps {
  author: Author;
}

export const AuthorCard: React.FC<AuthorCardProps> = ({ author }) => {
  return <Card imageUrl={author.imageUrl} title={author.name} />;
};
