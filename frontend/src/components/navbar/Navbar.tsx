import React, {
  createContext,
  useContext,
  useEffect,
  useState,
  FormEvent,
} from "react";
import { Link, Redirect } from "react-router-dom";
import { LoginContext } from "../login/LoginManager";
import "./Navbar.scss";

export const Navbar: React.FunctionComponent = () => {
  const loginContext = useContext(LoginContext);
  const [search, setSearch] = useState("");

  const handleSearch = (e: FormEvent<HTMLFormElement>) => {
    const searchRoute = "/search/" + search;
    return <Redirect to={searchRoute} />;
  };

  return (
    <nav className="navbar" role="navigation" aria-label="main navigation">
      <Link to="/">
        <img
          className="navbar__logo"
          src="/BookLabLogo.svg"
          alt="BookLab logo"
        />
      </Link>
      <Link to="/">BookLab</Link>
      <p>&#xb7;</p>
      <Link to="/books">Books</Link>
      <p>&#xb7;</p>
      <Link to="/authors">Authors</Link>
      <div className="search-form">
        <input
          type="text"
          placeholder="Search..."
          onChange={(e) => setSearch(e.target.value)}
        />
        <Link className="search-form__link" to={"/search/" + search}>
          <i className="fa-solid fa-magnifying-glass"></i>
        </Link>
      </div>
      {/* <div>
        {!loginContext.isLoggedIn ? (
          <div></div>
        ) : (
          <Link to="/">
            <a className="button is-primary" onClick={loginContext.logOut}>
              <strong>Logout</strong>
            </a>
          </Link>
        )}
      </div> */}
    </nav>
  );
};
