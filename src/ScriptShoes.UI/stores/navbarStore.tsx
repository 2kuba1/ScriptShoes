import { create } from 'zustand';

interface NavbarStore {
  isOpened: boolean;
  setIsOpened: (isOpened: boolean) => void;
  searchPhrase: string | null;
  setSearchPhrase: (searchPhrase: string) => void;
}

const useNavbarStore = create<NavbarStore>(set => ({
  isOpened: false,
  setIsOpened: isOpened => set(() => ({ isOpened: isOpened })),
  searchPhrase: null,
  setSearchPhrase: searchPhrase => set(() => ({ searchPhrase: searchPhrase })),
}));

export default useNavbarStore;
