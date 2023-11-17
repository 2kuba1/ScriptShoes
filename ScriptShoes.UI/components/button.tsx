'use client';

export interface Props extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  children: string;
  icon?: React.ReactElement;
}

const Button = (props: Props) => {
  const { children, icon, ...rest } = props;

  return (
    <button {...rest}>
      {icon}
      {children}
    </button>
  );
};

export default Button;
