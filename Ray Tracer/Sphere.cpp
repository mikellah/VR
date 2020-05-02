#include "Sphere.h"

using namespace rt;

Intersection Sphere::getIntersection(const Line& line, float minDist, float maxDist) {
	Vector origin = line.x0();
	Vector direction = line.dx();
	Vector oc = origin - _center;
	float a = direction * direction;
	float b = 2 * (oc * direction);
	float c = oc * oc - _radius * _radius;

	float delta = b * b - 4 * a * c;

	if (delta < 0) { // no intersection with the sphere
		return Intersection(false, this, &line, 0);
	}

	delta = sqrt(delta);
	float t0 = (-b - delta) / (2 * a);
	float t1 = (-b + delta) / (2 * a);
	float t = (t0 < t1) ? t0 : t1;

	if (t < minDist || t > maxDist) {
		return Intersection(false, this, &line, 0);
	}

	return Intersection(true, this, &line, t);
}


const Vector Sphere::normal(const Vector& vec) const {
	Vector n = vec - _center;
	n.normalize();
	return n;
}