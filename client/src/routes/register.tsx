import { createFileRoute } from "@tanstack/react-router";
import { RegisterForm } from "widgets";

export const Route = createFileRoute("/register")({
  component: () => <RegisterForm />,
});
