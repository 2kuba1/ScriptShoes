import { create } from 'zustand';

interface NavbarStore {
  isOpened: boolean;
  setIsOpened: (isOpened: boolean) => void;
}

const useNavbarStore = create<NavbarStore>(set => ({
  isOpened: false,
  setIsOpened: isOpened => set(() => ({ isOpened: isOpened })),
}));

export default useNavbarStore;
