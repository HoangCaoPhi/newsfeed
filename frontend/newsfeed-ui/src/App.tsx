import { Authenticated, Refine, WelcomePage } from "@refinedev/core";
import { dataProvider } from "./providers/data-provider";
import { authProvider } from "./providers/auth-provider";
import { Login } from "./components/app/login/Login";
import routerProvider from "@refinedev/react-router-v6";
import { Navigate, Outlet, Route, Routes, BrowserRouter } from "react-router-dom";
import { Header } from "./components";
import {Newsfeed} from "./components/app/newsfeed/NewsFeed"
import "./components/common/common.scss"
import "./components/common/common.scss"

export default function App() {
  return (
    <BrowserRouter>
      <Refine
        dataProvider={dataProvider}
        authProvider={authProvider}
        routerProvider={routerProvider}
      >
        <Routes>
          <Route
            element={
              <Authenticated key="protected" fallback={<Navigate to="/login" />}>
                <Outlet />
              </Authenticated>
            }
          >
            <Route index element={<Login />} />
          </Route>

          <Route
            element={
              <Authenticated key="auth-pages" fallback={<Outlet />}>
                <Navigate to="/" />
              </Authenticated>
            }
          >
            <Route path="/login" element={<Login login={authProvider.login} />} />
            <Route path="/resign" element={<Login login={authProvider.login} />} />
            <Route path="/newsfeed" element={<Newsfeed/>} />

          </Route>
        </Routes>
      </Refine>
    </BrowserRouter>


  );
}