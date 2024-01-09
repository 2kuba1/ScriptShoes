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

export interface DecodedToken {
  Id: string;
  Username: string;
  FirstName: string;
  LastName: string;
  Email: string;
  ProfilePicture: string;
  IsVerified: boolean;
  Role: string;
  nbf: number;
  exp: number;
  iss: string;
  aud: string;
}

export interface DecodedRefreshToken {
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
  const decodedRefreshToken = encodeURIComponent(refreshToken);

  const { data, error } = await fetchAsync<Token>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/user/refreshToken?refreshToken=${decodedRefreshToken}`,
    Method.GET
  );

  if (error) return null;
  return data;
};

export const refreshAccess = async (
  errorStatusCode: number,
  refreshToken: string
) => {
  if (errorStatusCode !== 401) return;

  var data = await refreshAccessToken(refreshToken);

  if (!data) return;

  return data;
};
