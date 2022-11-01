import { render, screen } from "@testing-library/react";
import { Home } from "../../components/homepage/Home";

test("renders BookLab text to screen", () => {
  render(<Home />);
  const elements = screen.getAllByText(/BookLab/i);
  expect(elements[0]).toBeInTheDocument();
});
