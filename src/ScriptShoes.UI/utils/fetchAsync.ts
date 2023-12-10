import axios, { AxiosError, AxiosRequestConfig } from 'axios';

interface FetchAsync<T> {
  error: AxiosError | null;
  data: T;
  refetch: (newHeaders: any) => Promise<RefetchAsync<T>>;
}

interface RefetchAsync<T> {
  refetchError: AxiosError | null;
  refetchData: T;
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
  body?: any,
  headers?: any
): Promise<FetchAsync<T>> => {
  let fetchData = {} as FetchAsync<T>;

  const config = {
    url: url,
    method: method,
    data: body ? body : null,
    headers: headers ? headers : null,
  } as AxiosRequestConfig;

  try {
    const { data }: { data: T } = await axios(config);
    fetchData.data = data;
  } catch (err) {
    if (err instanceof AxiosError) {
      fetchData.error = err;
    }
  }

  fetchData.refetch = async <T>(newHeaders: any | null) => {
    let refetchData = {} as RefetchAsync<T>;

    try {
      config.headers = newHeaders;

      const { data }: { data: T } = await axios(config);
      refetchData.refetchData = data;
    } catch (err) {
      if (err instanceof AxiosError) {
        refetchData.refetchError = err;
      }
    }

    return refetchData;
  };

  return fetchData;
};

export default fetchAsync;
