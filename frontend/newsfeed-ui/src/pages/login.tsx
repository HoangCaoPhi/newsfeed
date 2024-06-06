import React from "react";
import { AuthPage } from "@refinedev/mui";

export const Login = () => {
  return (
    <AuthPage
      type="login"
      formProps={{
        defaultValues: {
            email: "hoangphi123@gmail.com",
            password: "12345678@Abc",
        },
      }}
    />
  );
};