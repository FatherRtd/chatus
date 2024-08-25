import { ReactNode } from "@tanstack/react-router";
import { HTMLAttributes } from "react";

import classes from "./form-layout.module.css";

interface FormLayoutProps extends HTMLAttributes<HTMLFormElement> {
  children: ReactNode;
}

export const FormLayout = ({ children, ...props }: FormLayoutProps) => {
  return (
    <form className={classes.form} {...props}>
      {children}
    </form>
  );
};
