import React from "react";
import "./Card.scss";

interface CardProps {
  title: string;
  imageUrl: string;
}

export const Card: React.FC<CardProps> = ({ title, imageUrl, children }) => {
  return (
    <div className="card">
      <div className="card__image-container">
        <img className="card__img" src={imageUrl} alt={title} />
      </div>
      <div className="card__text">
        <div className="card__title">{title}</div>
        <div className="card__contents">{children}</div>
      </div>
    </div>
  );
};
