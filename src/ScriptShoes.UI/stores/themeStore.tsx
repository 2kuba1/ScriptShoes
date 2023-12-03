import { create } from 'zustand';

interface ThemeStore {
  theme: string;
  setTheme: (theme: string) => void;
}

const useThemeStore = create<ThemeStore>(set => ({
  theme: 'light',
  setTheme: theme => set(() => ({ theme: theme })),
}));

export default useThemeStore;
