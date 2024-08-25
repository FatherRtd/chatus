import { createFileRoute } from "@tanstack/react-router";
import { LoginForm } from "widgets";

export const Route = createFileRoute("/login")({
  component: () => <LoginForm />,
});
