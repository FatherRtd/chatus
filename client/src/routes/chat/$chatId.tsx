import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/chat/$chatId")({
  component: () => <div>Hello /chat/$chatId!</div>,
});
