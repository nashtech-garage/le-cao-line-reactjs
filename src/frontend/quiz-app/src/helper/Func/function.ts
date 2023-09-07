import { ID } from 'constants/constants';

export function mapBuilder(
  data: any[],
  field: string = ID
): { mapping: Record<any, any>; listing: any[] } {
  if (!Array.isArray(data) || data.length === 0) return { mapping: {}, listing: [] };
  const map: any = {};
  const dataNotUndefined = data.filter((d) => d);
  dataNotUndefined.forEach((d: any) => {
    if (!d[field]) return;
    map[d[field]] = { ...d };
  });

  return {
    mapping: map,
    listing: dataNotUndefined.map((d) => d[field]),
  };
}

export function calculateSize(size: number) {
  if (size) {
    return Number(size * 4);
  }

  return 0;
}
