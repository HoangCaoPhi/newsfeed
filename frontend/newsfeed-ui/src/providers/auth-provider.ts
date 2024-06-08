import { AuthProvider } from "@refinedev/core";
const API_URL = "https://localhost:44311/api/v1";
export const authProvider: AuthProvider = {

  check: async () => {
    const token = localStorage.getItem("token");

    console.log("Token", token);

    return { authenticated: Boolean(token) };
  },
  login: async (param: any) => {
    const response = await fetch(`${API_URL}/authentication/login`, {
      method: "POST",
      body: JSON.stringify(param),
      headers: {
        "Content-Type": "application/json",
      },
    })
    const data = await response.json();
    if (data?.data?.token) {
      localStorage.setItem("token", data.data.token);
      return { success: true };
    }

    return { success: false };
  },
  logout: async () => {
    localStorage.removeItem("token");
    return { success: true };
  },
  onError: async (error) => {
    throw new Error("Not implemented");
  },
};