import fetchAsync, { Method } from './fetchAsync';
import { cookies } from 'next/headers';

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

export const getAccessToken = async (email: string, password: string) => {
  const { data, error } = await fetchAsync<LoginResponse>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/user/login?email=${email}&password=${password}`,
    Method.POST
  );

  if (error) return null;

  const cookieStore = cookies();

  cookieStore.set('accessToken', data.accessToken, {
    expires: new Date(data.accessTokenExpirationTime),
  });
  cookieStore.set('refreshToken', data.refreshToken, {
    expires: new Date(data.refreshTokenExpirationTime),
  });

  return data;
};

export const refreshAccessToken = async (refreshToken: string) => {
  const { data, error } = await fetchAsync<Token>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/user/refreshToken?refreshToken=${refreshToken}`,
    Method.POST
  );

  if (error) return null;

  const cookieStore = cookies();
  cookieStore.set('accessToken', data.token, {
    expires: new Date(data.expires),
  });

  return data;
};
