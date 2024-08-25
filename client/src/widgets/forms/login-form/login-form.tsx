import { Button, PasswordInput, Text, TextInput, Title } from "@mantine/core";
import { Link, useNavigate } from "@tanstack/react-router";
import { FormLayout } from "shared";

export const LoginForm = () => {
  const navigate = useNavigate();
  return (
    <FormLayout onSubmit={() => navigate({ to: "/chat" })}>
      <Title order={1}>Вход</Title>
      <TextInput label="Логин" withAsterisk w="70%" />
      <PasswordInput label="Пароль" withAsterisk w="70%" />
      <Text size="sm">
        Нет аккаунта? <Link to="/register">Зарегистрироваться</Link>
      </Text>
      <Button size="md" variant="light" w="70%" type="submit">
        Войти
      </Button>
    </FormLayout>
  );
};
