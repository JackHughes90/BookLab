import React from "react";
import "./Card.scss";

interface CardProps {
  title: string;
  imageUrl: string;
  description: string;
}

export const Card: React.FC<CardProps> = ({
  title,
  imageUrl,
  description,
  children,
}) => {
  return (
    <div className="card">
      <img className="card__image" src={imageUrl} alt={title} />
      <h5 className="card__title">{title}</h5>
      <p className="card__description">{description}</p>
      <div className="card__contents">{children}</div>
    </div>
  );
};
