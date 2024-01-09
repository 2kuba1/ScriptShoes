import { cookies } from 'next/headers';
import { redirect } from 'next/navigation';
import { jwtDecode } from 'jwt-decode';
import { type DecodedToken, refreshAccess, refreshAccessToken } from './tokens';

const RequireAuth = async (userId: string) => {
  const cookieStore = cookies();

  const token = cookieStore.get('access_token');

  const refreshToken = cookieStore.get('refresh_token');

  if (!refreshToken) {
    redirect('/login');
  }

  if (!token) {
    const accessToken = await refreshAccessToken(
      decodeURIComponent(refreshToken.value)
    );

    if (!accessToken) {
      redirect('/login');
    }

    const decodedToken = jwtDecode(accessToken.token) as DecodedToken;

    if (decodedToken.Id !== userId) {
      redirect('/login');
    }

    return decodedToken;
  }

  const decodedToken = jwtDecode(token.value) as DecodedToken;

  if (!decodedToken || decodedToken.exp < Date.now() / 1000) {
    const accessToken = await refreshAccess(401, refreshToken.value);
    if (!accessToken) {
      redirect('/login');
    }
  }

  if (decodedToken.Id !== userId) {
    redirect('/login');
  }

  return decodedToken;
};

export default RequireAuth;
