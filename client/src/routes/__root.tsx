import { Center, MantineProvider } from "@mantine/core";
import { Outlet, createRootRoute } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";

export const Route = createRootRoute({
  component: () => (
    <MantineProvider defaultColorScheme="dark">
      <Center h="100dvh">
        <Outlet />
        <TanStackRouterDevtools />
      </Center>
    </MantineProvider>
  ),
});
