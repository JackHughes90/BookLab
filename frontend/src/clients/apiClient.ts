import { Console } from "console";

const backendUrl = process.env["REACT_APP_BACKEND_DOMAIN"];

export interface ListResponse<T> {
  items: T[];
}

export interface Book {
  id: number;
  title: string;
  coverUrl: string;
  description: string;
  authors: Author[];
  genres: Genre[];
}

export interface Author {
  id: number;
  name: string;
  books: Book[];
  description: string;
  imageUrl: string;
}

export interface Genre {
  id: number;
  name: string;
  books: Book[];
}

export const getAllBooks = async (): Promise<Book[]> => {
  const response = await fetch(`${backendUrl}/books`);
  const bookListResponse: ListResponse<Book> = await response.json();
  return bookListResponse.items;
};

export const getBookById = async (bookId: string): Promise<Book> => {
  const response = await fetch(`${backendUrl}/books/${bookId}`);
  console.log(response);
  return await response.json();
};
