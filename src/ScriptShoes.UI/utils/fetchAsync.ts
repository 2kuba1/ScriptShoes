import axios, { AxiosError } from 'axios';

interface FetchAsync<T> {
  error: AxiosError | null;
  data: T;
}

export enum Method {
  GET = 'GET',
  POST = 'POST',
  PUT = 'PUT',
  DELETE = 'DELETE',
  PATCH = 'PATCH',
}

const fetchAsync = async <T>(
  url: string,
  method: Method,
  body?: any
): Promise<FetchAsync<T>> => {
  let fetchData = {} as FetchAsync<T>;

  try {
    const { data }: { data: T } = await axios(url, {
      method: method,
      params: body ? body : null,
    });
    fetchData.data = data;
  } catch (err) {
    if (err instanceof AxiosError) {
      fetchData.error = err;
    }
  }

  return fetchData;
};

export default fetchAsync;
