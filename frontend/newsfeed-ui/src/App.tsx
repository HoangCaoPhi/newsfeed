import { Authenticated, Refine, WelcomePage } from "@refinedev/core";
import { dataProvider } from "./providers/data-provider";
import { authProvider } from "./providers/auth-provider";
import { Login } from "./pages/login";
import routerProvider from "@refinedev/react-router-v6";
import { Navigate, Outlet, Route, Routes, BrowserRouter } from "react-router-dom";
import { Header } from "./components";
import { ListPosts } from "./pages/home/list";

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
                <Header />
                <Outlet />
              </Authenticated>
            }
          >
            <Route index element={<ListPosts />} />
          </Route>

          <Route
            element={
              <Authenticated key="auth-pages" fallback={<Outlet />}>
                <Navigate to="/" />
              </Authenticated>
            }
          >
            <Route path="/login" element={<Login />} />
          </Route>
        </Routes>
      </Refine>
    </BrowserRouter>
  );
}