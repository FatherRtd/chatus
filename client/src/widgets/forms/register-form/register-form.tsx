import { Button, PasswordInput, Text, TextInput, Title } from "@mantine/core";
import { Link } from "@tanstack/react-router";
import { FormLayout } from "shared";

export const RegisterForm = () => {
  return (
    <FormLayout>
      <Title order={1}>Регистрация</Title>
      <TextInput
        label="Логин"
        description="Уникальный логин, по которому производится вход"
        withAsterisk
        w="70%"
      />
      <TextInput
        label="Имя пользователя"
        description="Публичное имя, видно другим пользователям"
        withAsterisk
        w="70%"
      />
      <PasswordInput
        label="Пароль"
        description="Пароль для входа в приложение"
        withAsterisk
        w="70%"
      />
      <Text size="sm">
        Уже есть аккаунт? <Link to="/login">Вход</Link>
      </Text>
      <Button size="md" variant="light" w="70%">
        Зарегистрироваться
      </Button>
    </FormLayout>
  );
};
