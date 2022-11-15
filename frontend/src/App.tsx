import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Home } from "./components/homepage/Home";
import { Books } from "./components/books/Books";
import { BookSingle } from "./components/book-single/BookSingle";
// import { Authors } from "./components/authors/Authors";
import { Navbar } from "./components/navbar/Navbar";
import { LoginManager } from "./components/login/LoginManager";
import { Footer } from "./components/footer/Footer";

const Routes: React.FunctionComponent = () => {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/books">
        <Books />
      </Route>
      <Route exact path="/books/:bookId">
        <BookSingle />
      </Route>
      {/* <Route exact path="/authors">
        <Authors />
      </Route> */}
    </Switch>
  );
};

const App: React.FunctionComponent = () => {
  return (
    <Router>
      <LoginManager>
        <Navbar />
        <main>
          <Routes />
        </main>
        <Footer />
      </LoginManager>
    </Router>
  );
};

export default App;
