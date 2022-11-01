import { render, screen } from "@testing-library/react";
import App from "./App";

test("renders booklab text to screen", () => {
  render(<App />);
  const elements = screen.getAllByText(/booklab/i);
  expect(elements[0]).toBeInTheDocument();
});
