import fetchAsync, { Method } from './fetchAsync';

export interface LoginResponse {
  accessToken: string;
  refreshToken: string;
  accessTokenExpirationTime: string;
  refreshTokenExpirationTime: string;
}

export interface Token {
  token: string;
  expires: string;
}

export const Login = async (email: string, password: string) => {
  const { data, error } = await fetchAsync<LoginResponse>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/user/login?email=${email}&password=${password}`,
    Method.GET
  );

  if (error) return null;

  return data;
};

export const refreshAccessToken = async (refreshToken: string) => {
  const { data, error } = await fetchAsync<Token>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/user/refreshToken?refreshToken=${refreshToken}`,
    Method.POST
  );

  if (error) return null;

  return data;
};
