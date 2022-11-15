import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { LoginContext } from "../login/LoginManager";
import "./Navbar.scss";

export const Navbar: React.FunctionComponent = () => {
  const loginContext = useContext(LoginContext);

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
      {/* <p>&#xb7;</p>
      <Link to="/">Authors</Link> */}
      <div>
        {!loginContext.isLoggedIn ? (
          <div></div>
        ) : (
          <Link to="/">
            <a className="button is-primary" onClick={loginContext.logOut}>
              <strong>Logout</strong>
            </a>
          </Link>
        )}
      </div>
    </nav>
  );
};
